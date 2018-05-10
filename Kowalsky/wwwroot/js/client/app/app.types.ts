module App.Models {
    'use strict';    

    export class ContactInfo {
        name: string;
        email: string;
        phone: string;
        comment: string;
        dssAggreementAccepted: boolean;

        constructor(name: string, email: string, phone: string, comment: string, dssAggreementAccepted: boolean) {
            this.name = name;
            this.email = email;
            this.phone = phone;
            this.comment = comment;
            this.dssAggreementAccepted = dssAggreementAccepted;
        }

        get Name() { return this.name; }
        set Name(name: string) { this.name = name; }
        get Email() { return this.email; }
        set Email(email: string) { this.email = email; }
        get Phone() { return this.phone; }
        set Phone(phone: string) { this.phone = phone; }
        get Comment() { return this.comment; }
        set Comment(comment: string) { this.comment = comment; }
        get DssAggreementAccepted() { return this.dssAggreementAccepted; }
        set DssAggreementAccepted(accepted: boolean) { this.dssAggreementAccepted = accepted; }
    }

}