export class Guest {
    constructor(data = {}) {
        this.id = data.id || null;
        this.firstName = data.firstName || '';
        this.lastName = data.lastName || '';
        this.phone = data.phone || '';
        this.email = data.email || '';
        this.passportNumber = data.passportNumber || '';
        this.dateOfBirth = data.dateOfBirth || null;
        this.address = data.address || '';
    }

    get fullName() {
        return `${this.firstName} ${this.lastName}`;
    }

    static fromJson(json) {
        return new Guest(json);
    }

    toJson() {
        return {
            id: this.id,
            firstName: this.firstName,
            lastName: this.lastName,
            phone: this.phone,
            email: this.email,
            passportNumber: this.passportNumber,
            dateOfBirth: this.dateOfBirth,
            address: this.address
        };
    }
} 