var rootApp;
(function (rootApp) {
    'use strict';
    var ConfigureRoutes = /** @class */ (function () {
        function ConfigureRoutes() {
        }
        ConfigureRoutes.prototype.otherwise = function (params) {
            //return params.redirectTo();
            throw new Error("Method not implemented.");
        };
        ConfigureRoutes.prototype.when = function (path, route) {
            throw new Error("Method not implemented.");
        };
        return ConfigureRoutes;
    }());
    rootApp.ConfigureRoutes = ConfigureRoutes;
})(rootApp || (rootApp = {}));
//# sourceMappingURL=configure-routes.js.map