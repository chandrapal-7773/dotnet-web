import { config } from "./config.js";



const defaultOptions = {
    //plugins: ["restore_on_backspace", "clear_button"],
    delimiter: ",",
    maxItems: null,
    valueField: "id",
    labelField: "name",
    searchField: ["name"],
}

const Select = function (options) {

    var _selectizeInstance = $(options.ele).selectize({
        ...defaultOptions, ...options,
        options: options.allOptions,
    });
}

export default Select;