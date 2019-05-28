module rootApp {
    'use strict';

    export class ConfigureRoutes implements ng.route.IRouteProvider {

        caseInsensitiveMatch?: boolean;
        otherwise(params: angular.route.IRoute): angular.route.IRouteProvider {
            //return params.redirectTo();
            throw new Error("Method not implemented.");
        }
        when(path: string, route: angular.route.IRoute): angular.route.IRouteProvider {
            throw new Error("Method not implemented.");
        }
        $get: any;


    }
}