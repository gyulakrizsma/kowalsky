module App.Models {
    'use strict';    

    export class ContactInfo {
        name: string;
        email: string;
        phone: string;
        comment: string;

        constructor(name: string, email: string, phone: string, comment: string) {
            this.name = name;
            this.email = email;
            this.phone = phone;
            this.comment = comment;
        }

        get Name() { return this.name; }
        set Name(name: string) { this.name = name; }
        get Email() { return this.email; }
        set Email(email: string) { this.email = email; }
        get Phone() { return this.phone; }
        set Phone(phone: string) { this.phone = phone; }
        get Comment() { return this.comment; }
        set Comment(comment: string) { this.comment = comment; }
    }

}