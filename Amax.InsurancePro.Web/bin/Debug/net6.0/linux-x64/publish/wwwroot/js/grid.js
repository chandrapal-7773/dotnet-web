import { config } from "./config.js";
import { apiClient } from "./apiClient.js";


function grid(options) {

    const BASEURL = config.baseUrl;
    var sel = null;
    var dt = null;

    const DEFAULT_OPTIONS = {
        dom: 'lrtip',
        serverSide: false,
        processing: true,
        width: '100%',
        autoWidth: false,
        deferRender: true,
        lengthMenu: [10, 15, 25, 50], // Set the page size options
        pageLength: 15, // Set the default number of records displayed
        ordering: false, // Enable or disable column ordering
        searching: true, // Enable or disable search functionality
        paging: true, // Enable or disable pagination
        info: false, // Enable or disable table information display
        lengthChange: false, // Enable or disable the ability to change the number of records displayed per page
    };

    this.addSearchtoColumn = function (cNum) {
        const columnNumber = cNum - 1;
        const ele = $(sel + ` thead tr th:nth(${columnNumber})`);
        var title = ele.text();
        ele.html(ele.text() + ' ' + '<input type="text" placeholder="Search ' + title + '" />');
        $('input', ele).on('keyup change', function () {
            if (dt.column(columnNumber).search() !== this.value) {
                dt.column(columnNumber)
                    .search(this.value)
                    .draw();
            }
        });
    }

    this.reload = function () {
        dt.ajax.reload();
    };

    this.getRowDataByFieldName = function (fieldName, searchValue) {

        if (!searchValue || !fieldName)
            return null;

        var hit = null;
        dt.rows().every(function (rowIdx, tableLoop, rowLoop) {
            var data = this.data();
            if (data[fieldName] == searchValue) {
                hit = data;
                return false;
            }
        });
        return hit;
    }

    this.initialize = function () {

        sel = options.selector;
        
        var dtOptions = { ...DEFAULT_OPTIONS, ...options.dtOptions };

        dtOptions.ajax = (data, callback, settings) => {
            apiClient.post(options.endpoint, { IsActiveOnly: options.isActiveOnly, start: 0, length: 10000 })
                .then(res => {
                    console.log("Response: ", res);
                    if (res.IsSuccess) {
                        var data = res.data;
                        if (options.customDataFilter) {
                            data.data = options.customDataFilter(res.data.data);
                            data.recordsFiltered = data.data.length;
                            data.recordsTotal = data.data.length;
                        } 
                        callback(data);
                    } else {
                        console.error(res);
                        throw new Error('Request failed');
                    }
                })
                .catch(e => {
                    console.error(e);
                });
        };

        dt = $(options.selector).DataTable(dtOptions);

        return dt;

    }

    this.initialize();
}

export default grid;
