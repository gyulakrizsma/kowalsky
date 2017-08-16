module Home {
    'use strict';

    import ContactInfo = App.Models.ContactInfo;

    export class ApiHome {

        static IID = 'register-services';

        constructor(private $http: angular.IHttpService) {}

        contact = (contactInfo: ContactInfo) => {
            return this.$http.post('/api/home',
                JSON.stringify(contactInfo),
                { headers: { 'Content-Type': 'application/json' } });
        }

    }

    angular
        .module('app.register')
        .service(ApiHome.IID, ApiHome);
}