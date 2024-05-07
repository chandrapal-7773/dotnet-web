import Grid from ".././grid.js";
import { apiEndpoints, showToast, confirmDialog } from "../common.js";
import { apiClient } from "../apiClient.js";
import FormHandler from "../formhandler.js";
import ListBox from "../listbox.js";


const gridSelector = "#agent-list";
const modalSelector = "#side-panel-form";
const saveBtn = document.querySelector(".heading-btns .save-btn");
const modalEle = document.querySelector(modalSelector);

var grid = null;
var formHandler = null;


const onAddSuccess = function (id) {
    showToast(`Successfuly added the new agent`);
    grid.reload();
}
const onEditSuccess = function (id) {
    var rowData = grid.getRowDataByFieldName("agentId", id);
    showToast(`Successfuly updated the agent named '${rowData?.agentName}'.`);
    grid.reload();
}
const onDeleteSuccess = function (id) {
    var rowData = grid.getRowDataByFieldName("agentId", id);
    showToast(`Successfuly delete the agent named '${rowData?.agentName}'.`);
    grid.reload();
}

const getAllAgencyOptions = async function () {
    return apiClient.post(apiEndpoints.agency.list, { start: 0, length: 10000 })
        .then(res => {
            if (res.IsSuccess) {
                return res.data.data;
            } else {
                console.error(res);
            }
        })
        .catch(e => {
            console.error(e);

        });
}

const agentTitleOptions = [
    { id: 'Accounting', name: 'Accounting' },
    { id: 'Agent/CSR', name: 'Agent/CSR' },
    { id: 'IT', name: 'IT' },
    { id: 'Marketing', name: 'Marketing' },
    { id: 'Office Manager', name: 'Office Manager' },
    { id: 'Operations', name: 'Operations' },
    { id: 'ROM', name: 'ROM' },
    { id: 'Zone Manager', name: 'Zone Manager' }
];

const initialize = async function () {

    var isDeletedOnly = false;
    const gridTitleEle = document.querySelector(".grid-title");
    if (gridTitleEle) {
        var searchParams = new URLSearchParams(window.location.search);

        if (searchParams.has("deleted") && searchParams.get("deleted") == "true") {
            isDeletedOnly = true;
            gridTitleEle.textContent = "Deleted Agents";
        } else {
            gridTitleEle.textContent = "Agents";
        }
    }

    grid = new Grid({
        selector: gridSelector,
        endpoint: apiEndpoints.agent.list,
        isActiveOnly: !isDeletedOnly,
        dtOptions: {
            
            columns: [
                //{ data: 'agentId', name: 'Id', visible: false },
                { data: 'agentName', name: 'Name' },
                { data: 'agentPhone1', name: 'Phone' },
                { data: 'email', name: 'Email' },
                { data: 'agentAddressLine1', name: 'Adress' },
                { data: 'agentCommPercent', name: 'Commission' },
                {
                    data: null,
                    name: 'Action',
                    data: null,
                    title: 'Actions',
                    render: function (data, type, row) {
                        // Customize the buttons based on your requirements

                        var html = '';

                        html += `<a href="#" data-id="${data.agentId}" class="grid-action-btn yellow-btn edit-btn"><i class="fas fa-pencil-alt"></i></a>`;

                        if (data.agentActive == 1) {
                            html += `<a href="#" data-id="${data.agentId}" class="grid-action-btn black-btn delete-btn"><i class="far fa-trash-alt"></i></a>`;
                        } else {
                            //TODO restore button
                        }
                        return html;
                    }
                },
            ]
        }
    });

    grid.addSearchtoColumn(1);
    //grid.addSearchtoColumn(3);

    //formhelper
    var allAgencies = await getAllAgencyOptions();
    var allOptions = allAgencies.map(a => { return { id: a.agencyId, name: a.agencyName } });

    formHandler = new FormHandler({
        modalEle: modalEle,
        editTitle: "Edit Agent",
        addTitle: "Add Agent",
        endpoints: {
            get: apiEndpoints.agent.get,
            add: apiEndpoints.agent.add,
            edit: apiEndpoints.agent.edit,
        },
        onAddSuccess: onAddSuccess,
        onEditSuccess: onEditSuccess,
        selectOptions: [
            {
                fieldName: "Title",
                allOptions: agentTitleOptions,
                closeAfterSelect: true,
                maxItems: 1,
                items: ['Agent/CSR'],

            }
        ],
        listBoxOptions: {
            containerSelector: "#agent-locations",
            allOptions: allOptions,
            fieldName: "selectedLocations",
            selectedOptionsName: "agencies",
            OptionIdField: "agencyId",
            OptionNameField: "agencyName"
        }
    });

}

const onEdit = function(id) {

    formHandler.initEdit(id);
}

const onSave = function () {

    formHandler.initSave();
}

const onDelete = function (id) {

    var rowData = grid.getRowDataByFieldName("agentId", id);

    var deleteMessage = `<div>Are you sure you want to delete agent named "<span style='font-weight:bold'>${rowData?.agentName}</span>" ?</div>`

    confirmDialog(deleteMessage, () => {
        apiClient.del(apiEndpoints.agent.del + '/' + id)
            .then(res => {
                if (res.IsSuccess) {
                    onDeleteSuccess(id);
                } else {
                    console.error('id=' + id, res);
                    showToast('Failed to delete the agent!' + id, false);
                }
            })
            .catch(e => {
                console.error('id=' + id, e);
                showToast('Failed to delete the agent!' + id, false);
            })
            .finally(() => {

            })
    });

}

const setEvents = function () {
    const table = document.querySelector(gridSelector);

    table.addEventListener('click', (e) => {
        const target = e.target;
        if (target.nodeName == 'A' && target.classList.contains("edit-btn")) {
            const id = target.getAttribute("data-id");
            onEdit(id);
        } else if (target.nodeName == 'A' && target.classList.contains("delete-btn")) {
            const id = target.getAttribute("data-id");
            console.log(id);
            onDelete(id);
            
        }
    });

    saveBtn.addEventListener('click', onSave);
    
}


document.addEventListener('DOMContentLoaded', async function () {

    initialize();

    setEvents();

});