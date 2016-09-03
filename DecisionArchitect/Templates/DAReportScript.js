!INC;
Local;
Scripts.EAConstants - JScript;
/* 
* WORK IN PROGRESS
* Script Name: DAReportScript
* Author: Hessel van Apeldoorn
* Purpose: To display the properties of all Decision Architect Objects
* Date: 07/07/2012
* 
* This JavaScript, together with the DAReport.xml, can be used in EAMain's template designer.
* It creates a report for a given EAMain project which demonstrates all functionality of the 
* Elements unique to Decision Architect plug-in.
*
* To create a report:
* - Import the xml file in the template designer
* - Include the JavaScript in the scripting section
* - Generate Documentation
*/

var DecisionMetaType = "Decision";
var TraceStereoType = "trace";

function createTopic(xmlDOM, xmlRow, element) {
    var i;
    var allElements = Repository.GetElementSet("select * from t_object", 2);
    var firstElement = 0;
    for (i = 0; i < allElements.Count; i++) {
        var decision = allElements.GetAt(i);
        if (decision.ParentID == element.ElementID) {
            xmlName = xmlDOM.createElement("decision");
            if (decision.Stereotype == "approved") {
                approvedDecision = decision;
            } else {
                xmlName.text += (",\ " + decision.Name);
            }
            xmlRow.appendChild(xmlName);
        }
    }
    xmlName = xmlDOM.createElement("approvedDecision");
    xmlName.text += approvedDecision.Name;
    xmlRow.appendChild(xmlName);

    xmlName = xmlDOM.createElement("approvedDecisionNotes");
    xmlName.text = approvedDecision.Notes;
    xmlRow.appendChild(xmlName);

    xmlName = xmlDOM.createElement("relatedElements");
    var connectors = element.Connectors;
    xmlName.text += "\nTraced elements:\ ";
    var firstTrace = 1;
    for (i = 0; i < connectors.Count; i++) {
        var connector = connectors.GetAt(i);
        Session.Output(connector.Stereotype);
        if (connector.Stereotype == "trace") {
            var client = Repository.GetElementByID(connector.ClientID);
            var supplier = Repository.GetElementByID(connector.SupplierID);
            if (firstTrace == 0) {
                xmlName.text += (",\ " + supplier.Name);
            } else {
                firstTrace = 0;
                xmlName.text += ("\ " + supplier.Name);
            }
        }
    }
    xmlRow.appendChild(xmlName);
    return xmlRow;
}

function GetTopicAlternatives(objectID) {

    var xmlDOM = new ActiveXObject("MSXML2.DOMDocument.4.0");
    xmlDOM.validateOnParse = false;
    xmlDOM.async = false;

    var node = xmlDOM.createProcessingInstruction("xml", "version='1.0'");
    xmlDOM.appendChild(node);

    var xmlRoot = xmlDOM.createElement("EAMainDATA");
    xmlDOM.appendChild(xmlRoot);

    var xmlDataSet = xmlDOM.createElement("Dataset_0");
    xmlRoot.appendChild(xmlDataSet);

    var xmlData = xmlDOM.createElement("Data");
    xmlDataSet.appendChild(xmlData);


    var topic = Repository.GetElementByID(objectID);
    var elements = topic.Elements;
    for (i = 0; i < elements.Count; i++) {
        var decision = elements.GetAt(i);
        if (IsDecision(decision)) {
            var xmlRow = xmlDOM.createElement("Row");
            xmlData.appendChild(xmlRow);
            xmlName = xmlDOM.createElement("topic_alternative");
            xmlName.text = decision.Name;
            xmlRow.appendChild(xmlName);
        }
    }

    return xmlDOM.xml;
}

function GetRelatedDecisions(objectID) {

    var xmlDOM = new ActiveXObject("MSXML2.DOMDocument.4.0");
    xmlDOM.validateOnParse = false;
    xmlDOM.async = false;

    var node = xmlDOM.createProcessingInstruction("xml", "version='1.0'");
    xmlDOM.appendChild(node);

    var xmlRoot = xmlDOM.createElement("EAMainDATA");
    xmlDOM.appendChild(xmlRoot);

    var xmlDataSet = xmlDOM.createElement("Dataset_0");
    xmlRoot.appendChild(xmlDataSet);

    var xmlData = xmlDOM.createElement("Data");
    xmlDataSet.appendChild(xmlData);

    var decision = Repository.GetElementByID(objectID);
    var connectors = decision.Connectors;

    for (i = 0; i < connectors.Count; i++) {
        var connector = connectors.GetAt(i);
        if (IsDecisionRelationship(connector)) {
            var relatedDecision;
            if (connector.ClientID == objectID) {
                relatedDecision = Repository.GetElementByID(connector.SupplierID);
            } else {
                relatedDecision = Repository.GetElementByID(connector.ClientID);
            }
            var xmlRow = xmlDOM.createElement("Row");
            xmlData.appendChild(xmlRow);
            xmlName = xmlDOM.createElement("decision_name");
            xmlName.text = relatedDecision.Name;
            xmlRow.appendChild(xmlName);
            xmlName = xmlDOM.createElement("decision_state");
            xmlName.text = relatedDecision.Stereotype;
            xmlRow.appendChild(xmlName);
        }
    }

    return xmlDOM.xml;
}

function GetTraces(objectID) {

    var xmlDOM = new ActiveXObject("MSXML2.DOMDocument.4.0");
    xmlDOM.validateOnParse = false;
    xmlDOM.async = false;

    var node = xmlDOM.createProcessingInstruction("xml", "version='1.0'");
    xmlDOM.appendChild(node);

    var xmlRoot = xmlDOM.createElement("EAMainDATA");
    xmlDOM.appendChild(xmlRoot);

    var xmlDataSet = xmlDOM.createElement("Dataset_0");
    xmlRoot.appendChild(xmlDataSet);

    var xmlData = xmlDOM.createElement("Data");
    xmlDataSet.appendChild(xmlData);

    var element = Repository.GetElementByID(objectID);
    var connectors = element.Connectors;

    for (i = 0; i < connectors.Count; i++) {
        var connector = connectors.GetAt(i);
        if (IsTrace(connector)) {
            var relatedDecision;
            if (connector.ClientID == objectID) {
                relatedDecision = Repository.GetElementByID(connector.SupplierID);
            } else {
                relatedDecision = Repository.GetElementByID(connector.ClientID);
            }
            var xmlRow = xmlDOM.createElement("Row");
            xmlData.appendChild(xmlRow);
            xmlName = xmlDOM.createElement("decision_name");
            xmlName.text = relatedDecision.Name;
            xmlRow.appendChild(xmlName);
            xmlName = xmlDOM.createElement("decision_state");
            xmlName.text = relatedDecision.Stereotype;
            xmlRow.appendChild(xmlName);
        }
    }

    return xmlDOM.xml;
}


function GetDescription(objectID) {

    var xmlDOM = new ActiveXObject("MSXML2.DOMDocument.4.0");
    xmlDOM.validateOnParse = false;
    xmlDOM.async = false;

    var node = xmlDOM.createProcessingInstruction("xml", "version='1.0'");
    xmlDOM.appendChild(node);

    var xmlRoot = xmlDOM.createElement("EAMainDATA");
    xmlDOM.appendChild(xmlRoot);

    var xmlDataSet = xmlDOM.createElement("Dataset_0");
    xmlRoot.appendChild(xmlDataSet);

    var xmlData = xmlDOM.createElement("Data");
    xmlDataSet.appendChild(xmlData);

    var element = Repository.GetElementByID(objectID);
    var xmlRow = xmlDOM.createElement("Row");
    xmlData.appendChild(xmlRow);
    xmlName = xmlDOM.createElement("description");
    xmlName.text = element.GetLinkedDocument();
    xmlRow.appendChild(xmlName);
    return xmlDOM.xml;
}

function GetHistory(objectID) {

    var xmlDOM = new ActiveXObject("MSXML2.DOMDocument.4.0");
    xmlDOM.validateOnParse = false;
    xmlDOM.async = false;

    var node = xmlDOM.createProcessingInstruction("xml", "version='1.0'");
    xmlDOM.appendChild(node);

    var xmlRoot = xmlDOM.createElement("EAMainDATA");
    xmlDOM.appendChild(xmlRoot);

    var xmlDataSet = xmlDOM.createElement("Dataset_0");
    xmlRoot.appendChild(xmlDataSet);

    var xmlData = xmlDOM.createElement("Data");
    xmlDataSet.appendChild(xmlData);

    var element = Repository.GetElementByID(objectID);
    var taggedValues = element.TaggedValues;
    for (i = 0; i < taggedValues.Count; i++) {
        var taggedValue = taggedValues.GetAt(i);
        if (taggedValue.Name == "DV.StateChange") {
            var xmlRow = xmlDOM.createElement("Row");
            xmlData.appendChild(xmlRow);
            xmlName = xmlDOM.createElement("history");
            xmlName.text = taggedValue.Value;
            xmlRow.appendChild(xmlName);
        }
    }
    return xmlDOM.xml;
}

function IsTrace(element) {
    return element.StereoType == TraceStereoType;
}


function IsDecision(element) {
    return element.MetaType == DecisionMetaType;
}

function IsDecisionRelationship(connector) {
    switch (connector.Stereotype) {
    case "depends on":
    case "caused by":
    case "excluded by":
    case "alternative for":
    case "replaces":
        return true;
    default:
        return false;
    }
}