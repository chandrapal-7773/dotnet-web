const FloatingOptionsPanel = function (options) {
    const currentEvent = options.event;
    const items = options.items;
    const self = this;

    const body = document.querySelector('body');

    var wrapper = document.createElement('div');
    wrapper.classList.add("floating-panel-wrapper");


    var floatingPanel = document.createElement('div');
    floatingPanel.classList.add('floating-panel');
    floatingPanel.style.top = (currentEvent.clientY + 10) + 'px';
    floatingPanel.style.left = (currentEvent.clientX + 10) + 'px';

    var ulist = document.createElement('ul');
    floatingPanel.appendChild(ulist);

    items.forEach(l => {

        var linkEle = document.createElement('li');
        linkEle.innerHTML = l.title;
        linkEle.addEventListener('click', l.onClick);
        ulist.appendChild(linkEle);
    });

    wrapper.appendChild(floatingPanel);

    wrapper.addEventListener('click', e => {
        if (e.target.closest(".floating-panel"))
            return;
        wrapper.remove();
        body.style.overflow = 'unset';
    })

    
    body.append(wrapper);
    body.style.overflow = 'hidden';
}

export default FloatingOptionsPanel;