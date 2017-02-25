namespace AntiForgeryToken {
    let module: ng.IModule = angular.module('app', []);

    module.controller('AppController', AntiForgeryToken.AppController);
}