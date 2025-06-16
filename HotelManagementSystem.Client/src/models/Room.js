export class Room {
    constructor(data = {}) {
        this.id = data.id || null;
        this.roomNumber = data.roomNumber || '';
        this.roomType = data.roomType || '';
        this.price = data.price || 0;
        this.isAvailable = data.isAvailable ?? true;
        this.description = data.description || '';
    }

    static fromJson(json) {
        return new Room(json);
    }

    toJson() {
        return {
            id: this.id,
            roomNumber: this.roomNumber,
            roomType: this.roomType,
            price: this.price,
            isAvailable: this.isAvailable,
            description: this.description
        };
    }
} 