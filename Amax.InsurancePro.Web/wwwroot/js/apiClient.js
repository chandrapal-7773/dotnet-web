import { config } from "./config.js";

const BASEURL = config.baseUrl;
const DEFAULT_OPTIONS = {
    headers: {
        'Content-Type': 'application/json',
        'Accept': 'application/json',
    },
    'Accept': 'application/json',
    credentials: 'same-origin',
};

function makeRequest(endpoint, options = {}) {

    const mergedOptions = { ...DEFAULT_OPTIONS, ...options }

    console.log('Making api call to endpoint:', endpoint);
    console.log('options:', mergedOptions);

    mergedOptions.body = JSON.stringify(mergedOptions.body);

    return fetch(`${BASEURL}${endpoint}`, mergedOptions)
        .then(async res => {
            if (res.ok) {
                if (res.headers.get('Content-Length') !== '0')
                    return {
                        IsSuccess: true,
                        data: await res.json()
                    };
                else {
                    return { IsSuccess: true };
                }
            } else {
                return {
                    IsSuccess: false,
                    data: await res.json()
                };
            }
        }).catch(e => { console.error(e); });
        
}

function get(endpoint, options = {}) {
        
    return makeRequest(endpoint, {... options, method:"GET"});
}

function post(endpoint, data, options = {}) {

    return makeRequest(endpoint, { ...options, method: "POST", body: data });
}

function del(endpoint, options = {}) {

    return makeRequest(endpoint, { ...options, method: "DELETE" });
}

export const apiClient = { get:get, post:post, del:del };