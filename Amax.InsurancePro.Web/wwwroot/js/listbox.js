

function ListBox(options) {

    const container = document.querySelector(options.containerSelector);
    const listBoxes = container.querySelectorAll('.listbox');
    const unselectedEle = container.querySelector('.listbox.left');
    const selectedEle = container.querySelector('.listbox.right');

    const leftSearch = container.querySelector(".left-search");
    const rightSearch = container.querySelector(".right-search");

    var leftBtn = container.querySelector(".move-left");
    var rightBtn = container.querySelector(".move-right");

    var all = options.allOptions;
    var unselected = [];
    var selected = options.selectedOptions || [];
    var filteredUnselected = [];
    var filteredSelected = [];


    const render = function () {
        unselectedEle.innerHTML = "";
        selectedEle.innerHTML = "";
        filteredUnselected.forEach((item, index) => {
            var newLi = document.createElement('li');
            newLi.setAttribute('item-id', item.id);
            newLi.textContent = item.name;

            unselectedEle.append(newLi);
        });
        filteredSelected.forEach((item, index) => {
            var newLi = document.createElement('li');
            newLi.setAttribute('item-id', item.id);
            newLi.textContent = item.name;

            selectedEle.append(newLi);
        });

    }

    const update = function () {
        unselected = all.filter(item => !selected.some(secondItem => secondItem.id === item.id));
        if (leftSearch.value) {
            filteredUnselected = unselected.filter(s => s.name.toLowerCase().includes(leftSearch.value.toLowerCase()));
        } else {
            filteredUnselected = unselected;
        }
        if (rightSearch.value) {
            filteredSelected = selected.filter(s => s.name.toLowerCase().includes(rightSearch.value.toLowerCase()));
        } else {
            filteredSelected = selected;
        }
        render();
    }

    const onRight = function () {
        var selectedItems = unselectedEle.querySelectorAll('.active');

        for (var i = 0; i < selectedItems.length; i++) {
            var id = parseInt(selectedItems[i].getAttribute("item-id"));
            var name = selectedItems[i].textContent;
            selected.push({
                id: id,
                name: name
            });
        }
        update();
    }

    const onLeft = function () {
        var unselectedItems = selectedEle.querySelectorAll('.active');
        var ids = Array.from(unselectedItems).map(i => parseInt(i.getAttribute("item-id")));
        selected = selected.filter(i => !ids.some(id => i.id == id));
        update();
    }


    const setEvents = function () {
        for (var i = 0; i < listBoxes.length; i++) {
            listBoxes[i].onclick = function (event) {
                if (event.target.nodeName === 'LI') {
                    var itemEle = event.target;
                    console.log(itemEle);
                    console.log(itemEle.getAttribute("list-id"));
                    if (itemEle.classList.contains("active")) {
                        itemEle.classList.remove("active");

                    } else {
                        itemEle.classList.add("active");

                    }

                }
            };
        }

        rightBtn.onclick = onRight;
        leftBtn.onclick = onLeft;

        leftSearch.addEventListener("input", (e) => {
            update();
        });
        rightSearch.addEventListener("input", (e) => {
            update();
        });
    }

    const initialize = function (options) {

        setEvents();
        update();
    }

    this.getSelected = function () {
        return selected;
    }

    initialize();
}


export default ListBox;