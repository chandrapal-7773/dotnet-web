import FloatingOptionsPanel from "./FloatingOptionsPanel.js";


const sideManageAgents = document.querySelector("#side-manage-agents");

const setEvents = function () {

    sideManageAgents.addEventListener('click', e => new FloatingOptionsPanel({
        event: e,
        items: [
            { title: 'Active Agents', onClick: (e) => { window.location.href = "/agent/list" } },
            { title: 'Deleted Agents', onClick: (e) => { window.location.href = "/agent/list?deleted=true" } },
        ]
    }));

}

document.addEventListener('DOMContentLoaded', async function () {

    setEvents();

});