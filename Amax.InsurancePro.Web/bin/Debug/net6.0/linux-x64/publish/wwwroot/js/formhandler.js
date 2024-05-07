import { apiClient } from "./apiClient.js";
import { apiEndpoints, showToast } from "./common.js";
import ListBox from "./listbox.js";
import Select from "./select.js";

const errorMessages = {
    validationFail: "There's an issue with your input. Please update and try again!",
    unknown: "There's an unknown error while submiting this form"

}

const MODES = {
    ADD: 1,
    EDIT: 2
}

function FormHandler(settings) {
    const modalEle = settings.modalEle;
    const loaderEle = modalEle.querySelector(".loader");
    const formEle = modalEle.querySelector("form");
    const formTitleEle = modalEle.querySelector(".offcanvas-title");
    const formErrorEle = modalEle.querySelector(".form-error.text-danger");
    var submitBtnEle = formEle.querySelector(".submit-btn");
    var closeBtnEle = modalEle.querySelector('.btn-close');
    var modalBs = new bootstrap.Offcanvas(modalEle);

    var listBoxOptions = settings.listBoxOptions || null;
    var selectBoxesOptions = settings.selectOptions || null;

    var formControls = [];
    var isLoading = false;
    var mode = null;
    var id = 0;
    var listBox = null;
    var selectBoxes = null;

    for (var i = 0; i < formEle.elements.length; i++) {
        if (formEle[i].name) {
            var control = {
                ele: formEle[i],
                name: formEle[i].name,
                type: formEle[i].type,
            }
            formControls.push(control);
        }
    }

    closeBtnEle.addEventListener('click', (e) => {
        if (isLoading)
            return;

        modalBs.hide();
    })

    const updateLoading = function (loading) {
        isLoading = loading;
        if (isLoading)
            loaderEle.classList.remove("d-none");
        else
            loaderEle.classList.add("d-none");
    }

    const resetForm = function () {

        formEle.reset();

        formErrorEle.innerText = "";

        formEle.parentElement.scrollTop = 0;

        formControls.forEach(c => {
            var errEle = c.ele.parentElement.querySelector('span.text-danger');
            if (errEle) {
                errEle.innerText = "";
            }
            if (c.ele.tagName == 'SELECT') {
                c.ele.selectize?.destroy();
            }
        });

        var newBtnEle = submitBtnEle.cloneNode(true);
        submitBtnEle.parentElement.replaceChild(newBtnEle, submitBtnEle);
        submitBtnEle = newBtnEle;

        id = 0;
        if (listBox) {
            listBox = null;
        }

        //newBtnEle = closeBtnEle.cloneNode(true);
        //closeBtnEle.parentElement.replaceChild(newBtnEle, closeBtnEle);
        //closeBtnEle = newBtnEle;
    }

    const populateFields = function () {
        updateLoading(true);
        apiClient.get(`${settings.endpoints.get}${id}`)
            .then(res => {
                if (res.IsSuccess) {
                    const data = res.data;

                    formControls.forEach(control => {
                        const name = control.name.charAt(0).toLowerCase() + control.name.slice(1);
                        if (control.type === "text" || control.type === "textarea") {
                            control.ele.value = data[name] || "";
                        } else if (control.type === "number") {
                            control.ele.value = data[name] || 0;
                        }
                        else if (control.type === "checkbox") {
                            control.ele.checked = data[name] || false;
                        }
                    });

                    if (listBoxOptions) {
                        listBox = new ListBox({
                            containerSelector: listBoxOptions.containerSelector,
                            allOptions: listBoxOptions.allOptions,
                            selectedOptions: data[settings.listBoxOptions.selectedOptionsName]?.map(so => {
                                return { id: so[settings.listBoxOptions.OptionIdField], name: so[settings.listBoxOptions.OptionNameField] };
                            }),
                        });
                    }

                    if (selectBoxesOptions) {
                        selectBoxesOptions.forEach(sb => {
                            var fc = formControls.find(f => f.name == sb.fieldName);
                            const name = fc.name.charAt(0).toLowerCase() + fc.name.slice(1);
                            var curSelected = data[name];
                            selectBoxes.push(new Select({ ...sb, ele: fc.ele, items: [curSelected] }));
                        })
                    }
                }
            })
            .catch(e => {
                console.error(e);

            })
            .finally(() => {
                updateLoading(false);
            })
    }

    const updateErrors = (res) => {

        formErrorEle.innerText = "";
        formControls.forEach(c => {
            var errEle = c.ele.parentElement.querySelector('span.text-danger');
            if (errEle) {
                errEle.innerText = "";
            }
        });

        const code = res.data.Code;
        switch (code) {
            case 401:
                formErrorEle.innerText = res.data.Message;
                break;
            default:
                var errorResponse = res.data;
                if (errorResponse.ValidationErrors.length) {
                    formErrorEle.innerText = errorMessages.validationFail;

                    errorResponse.ValidationErrors.forEach((error,index) => {
                        var controlInfo = formControls.find(c => c.name == error.PropertyName);
                        var errEle = controlInfo.ele.parentElement.querySelector('span.text-danger');
                        if (errEle) {
                            errEle.innerText = error.ErrorMessage
                        }
                        
                    })
                } else {
                    formErrorEle.innerText = `Code(${res.data.Code}): ${res.data.Message}`;
                    formErrorEle.scrollIntoView();
                }
                break;
        }

        formControls.some(c => {
            if (c.ele.nextElementSibling && c.ele.nextElementSibling.classList.contains('text-danger') && c.ele.nextElementSibling.innerText != "") {
                c.ele.focus();
                return true;
            }
        })

    }

    const onSuccess = function (res) {
        modalBs.hide();
        if (mode == MODES.ADD)
            settings.onAddSuccess(res?.data?.id);
        else
            settings.onEditSuccess(res?.data?.id);
    }

    const postForm = function () {
        var url = "";
        if (mode == MODES.EDIT) {
            url = settings.endpoints.edit + id;
        } else {
            url = settings.endpoints.add;
        }

        var request = formControls.reduce((result, curValue) => {
            if (curValue.type == "text" || curValue.type == "textarea") {
                result[curValue.name] = curValue.ele.value;
            } else if (curValue.type == "number") {
                result[curValue.name] = curValue.ele.value == "" ? 0 : curValue.ele.vale;
            }
            else if (curValue.type == "checkbox") {
                result[curValue.name] = curValue.ele.checked;
            }           
            return result;
        }, {});

        if (selectBoxesOptions) {
            selectBoxesOptions.forEach(so => {
                request[so.fieldName] = formControls.find(f => f.name == so.fieldName).ele.value;
            })
        }

        if (listBox) {
            let selected = listBox.getSelected();
            request[listBoxOptions.fieldName] = selected.map(o => o.id);
        }

        updateLoading(true);
        
        apiClient.post(url, request)
            .then(res => {
                if (res.IsSuccess) {
                    onSuccess(res);
                } else {
                    updateErrors(res);
                }
            })
            .catch(e => {
                console.error(e);
                formErrorEle.innerText = errorMessages.unknown;
            })
            .finally(() => {
                updateLoading(false);
            })
    }

    this.initEdit = function (modelId) {
        resetForm();
        mode = MODES.EDIT;
        id = modelId;
        submitBtnEle.innerText = "Update";
        formTitleEle.innerText = settings.editTitle;

        selectBoxes = [];
        populateFields();

        submitBtnEle.addEventListener('click', () => {
            //getvalues
            //post
            postForm();
        });

        modalBs.show();
    }

    this.initSave = function () {
        resetForm();
        mode = MODES.ADD;
        submitBtnEle.innerText = "Save";
        formTitleEle.innerText = settings.addTitle;

        selectBoxes = [];

        if (selectBoxesOptions) {
            selectBoxesOptions.forEach(sb => {
                var fc = formControls.find(f => f.name == sb.fieldName);
                selectBoxes.push(new Select({ ...sb, ele: fc.ele }));
            })
        }

        if (listBoxOptions) {
            listBox = new ListBox({
                containerSelector: listBoxOptions.containerSelector,
                allOptions: listBoxOptions.allOptions,
            })
        }

        submitBtnEle.addEventListener('click', postForm);


        modalBs.show();
    }
}

export default FormHandler;