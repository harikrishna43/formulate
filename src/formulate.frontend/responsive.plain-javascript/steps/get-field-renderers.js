/**
 * Returns the field renderers in an associative array with the keys being the
 * type of field renderer (e.g., "text" or "button") and the value being the
 * function that renders the field.
 * @returns {{}} The associative array of field renderers.
 */
function getFieldRenderers() {

    // Variables.
    let i, fields, extraFields, field, fieldKey, fieldMap;

    // Get the field renderers.
    fields = [
        require("../fields/plain-text"),
        require("../fields/plain-button"),
        require("../fields/plain-rich-text"),
        require("../fields/plain-checkbox"),
        require("../fields/plain-textarea"),
        require("../fields/plain-hidden"),
        require("../fields/plain-select")
    ];
    extraFields = window["formulate-plain-js-fields"] || [];
    fields = fields.concat(extraFields);

    // Store the field renderers to an associative array.
    fieldMap = {};
    for (i = 0; i < fields.length; i++) {
        field = fields[i];
        fieldKey = field.key;
        fieldMap[fieldKey] = field.renderer;
    }

    // Return the associative array of field renderers.
    return fieldMap;

}

// Export the function that gets the field renderers.
module.exports = getFieldRenderers;