//import { test } from ".././common.js";
import { apiClient } from ".././apiClient.js";

const errorMessages = {
    validationFail: "There's an issue with your input. Please update and try again!",
    unknown: "There's an unknown error while submiting this form"

}
const formEle = document.getElementById("login");
const formErrorEle = document.querySelector(".form-error.text-danger");

var formControls =
    [
        { name: "Username" },
        { name: "Password" }
    ]

formControls.forEach((fc, i) => formControls[i].ele = document.getElementsByName(fc.name)[0]);

const updateErrors = (res) => {

    const code = res.data.Code;
    switch (code) {
        case 401:
            formErrorEle.innerText = res.data.Message;
            break;
        default:
            var errorResponse = res.data;
            if (errorResponse.ValidationErrors.length) {
                formErrorEle.innerText = errorMessages.validationFail;

                errorResponse.ValidationErrors.forEach(error => {
                    var controlInfo = formControls.find(c => c.name == error.PropertyName);
                    controlInfo.ele.nextElementSibling.innerText = error.ErrorMessage
                })
            } else {
                formErrorEle.innerText = `Code(${res.data.Code}): ${res.data.Message}`;
            }
            break;
    }


}

const clearErrors = () => {
    formErrorEle.innerText = "";
    formControls.forEach(c => c.ele.nextElementSibling.innerText = "");
}

formEle.onsubmit = (e) => {

    e.preventDefault();

    var submitButton = formEle.querySelector('button[type="submit"]');
    submitButton.disabled = true;

    clearErrors();


    var request = formControls.reduce((result, curValue) => {
        result[curValue.name] = curValue.ele.value;
        return result;
    }, {});

    apiClient.post("/auth/login", request)
        .then(res => {
            console.log("Response: ", res);
            if (res.IsSuccess) {
                const urlParams = new URLSearchParams(window.location.search);
                if (urlParams.has('ReturnUrl')) {
                    const returnUrl = urlParams.get('ReturnUrl');
                    window.location.href = decodeURIComponent(returnUrl);
                } else {
                    window.location.href = '/home/index';
                }
            } else {
                updateErrors(res);
            }
        })
        .catch(e => {
            console.error(e);
            formErrorEle.innerText = errorMessages.unknown;
        })
        .finally(() => {
            submitButton.disabled = false;
        })


}





