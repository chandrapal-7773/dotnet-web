import Grid from ".././grid.js";
import { apiEndpoints, showToast, confirmDialog } from "../common.js";
import { apiClient } from "../apiClient.js";
import FormHandler from "../formhandler.js";
import ListBox from "../listbox.js";


const gridSelector = "#company-list";
const modalSelector = "#side-panel-form";
const saveBtn = document.querySelector(".heading-btns .save-btn");
const modalEle = document.querySelector(modalSelector);

var grid = null;
var formHandler = null;


const onAddSuccess = function (id) {
    showToast(`Successfuly added the new company`);
    grid.reload();
}
const onEditSuccess = function (id) {
    var rowData = grid.getRowDataByFieldName("companyID", id);
    showToast(`Successfuly updated the company named '${rowData?.companyName}'.`);
    grid.reload();
}
const onDeleteSuccess = function (id) {
    var rowData = grid.getRowDataByFieldName("companyID", id);
    showToast(`Successfuly delete the company named '${rowData?.companyName}'.`);
    grid.reload();
}


const initialize = async function () {

    var isDeletedOnly = false;
    const gridTitleEle = document.querySelector(".grid-title");
    if (gridTitleEle) {
        var searchParams = new URLSearchParams(window.location.search);

        if (searchParams.has("deleted") && searchParams.get("deleted") == "true") {
            isDeletedOnly = true;
            gridTitleEle.textContent = "Deleted Companies";
        } else {
            gridTitleEle.textContent = "Companies";
        }
    }

    grid = new Grid({
        selector: gridSelector,
        endpoint: apiEndpoints.company.list,
        isActiveOnly: !isDeletedOnly,
        dtOptions: {
            columns: [
                { data: 'coName', name: 'Name' },
                { data: 'coAddressLine1', name: 'Address' },
                { data: 'coAddressCity', name: 'City' },
                { data: 'coAddressState', name: 'State' },
                { data: 'coContact', name: 'Contact' },
                {
                    data: null,
                    name: 'Action',
                    data: null,
                    title: 'Actions',
                    render: function (data, type, row) {
                        // Customize the buttons based on your requirements

                        var html = '';

                        html += `<a href="#" data-id="${data.companyID}" class="grid-action-btn yellow-btn edit-btn"><i class="fas fa-pencil-alt"></i></a>`;

                        if (data.deleted == 0) {
                            html += `<a href="#" data-id="${data.companyID}" class="grid-action-btn black-btn delete-btn"><i class="far fa-trash-alt"></i></a>`;
                        } else {
                            //TODO restore button
                        }
                        return html;
                    }
                },
            ],
        }
    });

    grid.addSearchtoColumn(1);

    //formhelper
    formHandler = new FormHandler({
        modalEle: modalEle,
        editTitle: "Edit Company",
        addTitle: "Add Company",
        endpoints: {
            get: apiEndpoints.company.get,
            add: apiEndpoints.company.add,
            edit: apiEndpoints.company.edit,
        },
        onAddSuccess: onAddSuccess,
        onEditSuccess: onEditSuccess,
        selectOptions: [
            {
                fieldName: "CommColl",
                allOptions: [
                    { id: 0, name: 'Check to Agency' },
                    { id: 1, name: 'Agency retains from Downpayment' },
                    { id: 2, name: 'Direct Deposit' },
                ],
                closeAfterSelect: true,
                maxItems: 1,
                items: [0],

            },
            {
                fieldName: "CommBase",
                allOptions: [
                    { id: 0, name: 'Premium for entire term' },
                    { id: 1, name: 'Month to Month Payment' },
                ],
                closeAfterSelect: true,
                maxItems: 1,
                items: [0],

            },
            {
                fieldName: "CoPayMethod",
                allOptions: [
                    { id: 0, name: 'Agency Check' },
                    { id: 1, name: 'Direct Debit' },
                    { id: 2, name: 'Deduct from Commission' },
                ],
                closeAfterSelect: true,
                maxItems: 1,
                items: [0],

            },
            {
                fieldName: "CompFeeOptions",
                allOptions: [
                    { id: 0, name: 'Collected upfront' },
                    { id: 1, name: 'Divided among Payments' },
                ],
                closeAfterSelect: true,
                maxItems: 1,
                items: [0],

            },
        ],
    });

}

const onEdit = function (id) {

    formHandler.initEdit(id);
}

const onSave = function () {

    formHandler.initSave();
}

const onDelete = function (id) {

    var rowData = grid.getRowDataByFieldName("companyID", id);

    var deleteMessage = `<div>Are you sure you want to delete company named "<span style='font-weight:bold'>${rowData?.coName}</span>" ?</div>`

    confirmDialog(deleteMessage, () => {
        apiClient.del(apiEndpoints.company.del + '/' + id)
            .then(res => {
                if (res.IsSuccess) {
                    onDeleteSuccess(id);
                } else {
                    console.error('id=' + id, res);
                    showToast('Failed to delete the company!' + id, false);
                }
            })
            .catch(e => {
                console.error('id=' + id, e);
                showToast('Failed to delete the company!' + id, false);
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