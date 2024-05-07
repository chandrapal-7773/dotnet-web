export const apiEndpoints = {

    auth: {
        login: "/auth/login",
    },
    agent: {
        get: "/api/agent/get/",
        add: "/api/agent/add",
        edit: "/api/agent/edit/",
        del: "/api/agent/delete",
        list: "/api/agent/list",

    },    
    agency: {
        get: "/api/agency/get/",
        add: "/api/agency/add",
        edit: "/api/agency/edit/",
        del: "/api/agency/delete",
        list: "/api/agency/list",

    },
    company: {
        get: "/api/company/get/",
        add: "/api/company/add",
        edit: "/api/company/edit/",
        del: "/api/company/delete",
        list: "/api/company/list",
    }
}


export function showToast(message, success=true) {
    var toast = $(`<div class="toast show ${success? 'success' : 'alert'}-toast" role="alert" aria-live="assertive" aria-atomic="true">
            <div class="toast-header">
                <strong class="me-auto">${success ? 'Success' : 'Alert'}</strong>
                <button type="button" class="btn-close" data-bs-dismiss="toast" aria-label="Close"></button>
            </div>
            <div class="toast-body">
                ${message}
            </div>
        </div>`);

    $('.toast-container').append(toast);

    toast.toast({ animation: true, autohide: true, delay:15000});

    toast.toast('show');

    toast.on('hidden.bs.toast', function () {
        $(this).remove();
    });
}

export function confirmDialog(message, onSuccess) {
    var container = document.querySelector(".modal-wrapper");
    const html = `<div class="modal fade" id="confirm-dialog" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Confirm</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    ${message}
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary close-btn" data-bs-dismiss="modal">Close</button>
                    <button type="button" class="btn red-btn yes-btn">Yes</button>
                </div>
            </div>
        </div>
    </div>`;

    const eleParent = document.createElement('div');
    eleParent.innerHTML = html;
    container.appendChild(eleParent);

    const ele = eleParent.firstChild;

    const cleanup = function () {
        modalBs.dispose();
        eleParent.remove();
    }

    var modalBs = new bootstrap.Modal(ele, { backdrop: 'static', keyboard: false, focus: true });

    ele.querySelector(".yes-btn").addEventListener('click', () => {
        onSuccess();
        modalBs.hide();
    });    

    ele.addEventListener('hidden.bs.modal', function (event) {
        cleanup();
    });

    modalBs.show();

}