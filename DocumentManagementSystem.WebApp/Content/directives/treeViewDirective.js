var rootApp;
(function (rootApp) {
    'use strict';
    var treeViewDirective = /** @class */ (function () {
        //public templateUrl: string = '/Content/directives/documentTreeView.html';
        function treeViewDirective($compile) {
            var _this = this;
            this.$compile = $compile;
            this.restrict = "E";
            this.link = function (scope, element, attributes) {
                //tree id
                var treeId = attributes.treeId;
                //tree model
                var treeModel = attributes.treeModel;
                //node id
                var nodeId = attributes.nodeId || 'id';
                //node label
                var nodeLabel = attributes.nodeLabel || 'label';
                //children
                var nodeChildren = attributes.nodeChildren || 'children';
                //tree template
                var template = '<ul>' +
                    '<li data-ng-repeat="node in ' + treeModel + '">' +
                    '<i class="collapsed" data-ng-show="node.' + nodeChildren + '.length && node.collapsed" data-ng-click="' + treeId + '.selectNodeHead(node)"></i>' +
                    '<i class="expanded" data-ng-show="node.' + nodeChildren + '.length && !node.collapsed" data-ng-click="' + treeId + '.selectNodeHead(node)"></i>' +
                    '<i class="normal" data-ng-hide="node.' + nodeChildren + '.length"></i> ' +
                    '<span data-ng-class="node.selected" data-ng-click="' + treeId + '.selectNodeLabel(node)">{{node.' + nodeLabel + '}}</span>' +
                    '<div data-ng-hide="node.collapsed" data-tree-id="' + treeId + '" data-tree-model="node.' + nodeChildren + '" data-node-id=' + nodeId + ' data-node-label=' + nodeLabel + ' data-node-children=' + nodeChildren + '></div>' +
                    '</li>' +
                    '</ul>';
                //check tree id, tree model
                if (treeId && treeModel) {
                    //root node
                    if (attributes.treeView) {
                        //create tree object if not exists
                        scope[treeId] = scope[treeId] || {};
                        //if node head clicks,
                        scope[treeId].selectNodeHead = scope[treeId].selectNodeHead || function (selectedNode) {
                            //Collapse or Expand
                            selectedNode.collapsed = !selectedNode.collapsed;
                        };
                        //if node label clicks,
                        scope[treeId].selectNodeLabel = scope[treeId].selectNodeLabel || function (selectedNode) {
                            //remove highlight from previous node
                            if (scope[treeId].currentNode && scope[treeId].currentNode.selected) {
                                scope[treeId].currentNode.selected = undefined;
                            }
                            //set highlight to selected node
                            selectedNode.selected = 'selected';
                            //set currentNode
                            scope[treeId].currentNode = selectedNode;
                        };
                    }
                    //Rendering template.
                    element.html('').append(_this.$compile(template)(scope));
                }
            };
        }
        treeViewDirective.Factory = function () {
            var directive = function ($compile) { return new treeViewDirective($compile); };
            directive.$inject = ['$compile'];
            return directive;
        };
        return treeViewDirective;
    }());
    rootApp.treeViewDirective = treeViewDirective;
})(rootApp || (rootApp = {}));
//# sourceMappingURL=treeViewDirective.js.map