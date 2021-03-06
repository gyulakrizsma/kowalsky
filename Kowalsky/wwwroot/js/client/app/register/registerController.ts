module Home {
    'use strict';

    import ContactInfo = App.Models.ContactInfo

    export class RegisterController implements angular.IController {

        static IID = 'RegisterController';
        static $inject = [ApiHome.IID];

        private contactInfo: ContactInfo;

        private registerForm: angular.IFormController;
        private hasRegistered?: boolean = null;

        constructor(private api: Home.ApiHome) {

            this.contactInfo = new ContactInfo('', '', '', '', false);

        }

        $onInit = () => { };

        get ContactInfo() { return this.contactInfo; }
        get HasErrors() {
            return this.registerForm.$submitted && this.registerForm.$invalid;
        }
        get InvalidDss() {
            return this.contactInfo.DssAggreementAccepted === undefined ||
                (this.registerForm.$submitted && !this.contactInfo.DssAggreementAccepted);
        }


        save = () => {
            this.registerForm.$setSubmitted();

            if (!this.HasErrors) {

                this.api.contact(this.contactInfo)
                    .then((result) => {

                        if (result.status === 200) {
                            this.hasRegistered = true;
                        } else {
                            this.hasRegistered = false;
                        }

                    });
            }
        }

        focusoutphone = () => {
            if (this.contactInfo.Phone !== undefined) {
                let firstTwo = this.contactInfo.Phone.substring(0, 2);
                if (firstTwo === "06")
                    return;

                this.contactInfo.Phone = this.contactInfo.Phone.replace(/^0+/, "").replace(/ /g, "");
            }
        }

        private successfullyRegistered = () => {
            
        }

        private failedToRegister = () => {
            
        }

    }

    angular.module('app.register').controller(RegisterController.IID, RegisterController);

}