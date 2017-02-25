namespace AntiForgeryToken {
    export class AppController {
        public requestSuccess: boolean = false;
        public requestFailure: boolean = false;

        static $inject = [
            '$http'
        ];

        constructor(
            private $http: ng.IHttpService
        ) {

        }

        public saveData(): void {
            let data: string = 'Hello  World';
            let self = this;

            this.requestFailure = false;
            this.requestSuccess = false;

            this.$http.post('/api/values', data)
                .then(function () {
                    self.requestSuccess = true;
                })
                .catch(function () {
                    self.requestFailure = true;
                });
        }
    }
}