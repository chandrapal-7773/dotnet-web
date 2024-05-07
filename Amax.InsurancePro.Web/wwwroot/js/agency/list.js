import Grid from ".././grid.js";
import { apiEndpoints, showToast, confirmDialog } from "../common.js";
import { apiClient } from "../apiClient.js";
import FormHandler from "../formhandler.js";
import ListBox from "../listbox.js";


const gridSelector = "#agency-list";
const modalSelector = "#side-panel-form";
const saveBtn = document.querySelector(".heading-btns .save-btn");
const modalEle = document.querySelector(modalSelector);

var grid = null;
var formHandler = null;


const onAddSuccess = function (id) {
    showToast(`Successfuly added the new agency`);
    grid.reload();
}
const onEditSuccess = function (id) {
    var rowData = grid.getRowDataByFieldName("agencyId", id);
    showToast(`Successfuly updated the agency named '${rowData?.agencyName}'.`);
    grid.reload();
}
const onDeleteSuccess = function (id) {
    var rowData = grid.getRowDataByFieldName("agencyId", id);
    showToast(`Successfuly delete the agency named '${rowData?.agencyName}'.`);
    grid.reload();
}


const initialize = async function () {

    var isDeletedOnly = false;

    grid = new Grid({
        selector: "#agency-list",
        endpoint: apiEndpoints.agency.list,
        isActiveOnly: !isDeletedOnly,
        dtOptions: {
            columns: [
                //{ data: 'agencyId', name: 'Id', visible: false },
                { data: 'agencyName', name: 'Name' },
                { data: 'agencyPhone1', name: 'Phone' },
                { data: 'agencyAddressLine1', name: 'Location' },
                { data: 'agencyAddressCity', name: 'City' },
                { data: 'agencyAddressState', name: 'State' },
                { data: 'agencyAddressZip', name: 'Zip' },
                {
                    data: null,
                    name: 'Action',
                    data: null,
                    title: 'Actions',
                    render: function (data, type, row) {
                        // Customize the buttons based on your requirements

                        var html = '';

                        html += `<a href="#" data-id="${data.agencyId}" class="grid-action-btn yellow-btn edit-btn"><i class="fas fa-pencil-alt"></i></a>`;
                        
                        if (data.deleted == 0) {
                            html += `<a href="#" data-id="${data.agencyId}" class="grid-action-btn black-btn delete-btn"><i class="far fa-trash-alt"></i></a>`;
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
    grid.addSearchtoColumn(3);
    grid.addSearchtoColumn(4);

    //formhelper
    formHandler = new FormHandler({
        modalEle: modalEle,
        editTitle: "Edit Agency",
        addTitle: "Add Agency",
        endpoints: {
            get: apiEndpoints.agency.get,
            add: apiEndpoints.agency.add,
            edit: apiEndpoints.agency.edit,
        },
        onAddSuccess: onAddSuccess,
        onEditSuccess: onEditSuccess,
    });

}

const onEdit = function (id) {

    formHandler.initEdit(id);
}

const onSave = function () {

    formHandler.initSave();
}

const onDelete = function (id) {

    var rowData = grid.getRowDataByFieldName("agencyId", id);

    var deleteMessage = `<div>Are you sure you want to delete agency named "<span style='font-weight:bold'>${rowData?.agencyName}</span>" ?</div>`

    confirmDialog(deleteMessage, () => {
        apiClient.del(apiEndpoints.agency.del + '/' + id)
            .then(res => {
                if (res.IsSuccess) {
                    onDeleteSuccess(id);
                } else {
                    console.error('id=' + id, res);
                    showToast('Failed to delete the agency!' + id, false);
                }
            })
            .catch(e => {
                console.error('id=' + id, e);
                showToast('Failed to delete the agency!' + id, false);
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