export class Booking {
    constructor(data = {}) {
        this.id = data.id || null;
        this.guestId = data.guestId || null;
        this.roomId = data.roomId || null;
        this.checkIn = data.checkIn || null;
        this.checkOut = data.checkOut || null;
        this.status = data.status || 'pending'; // pending, confirmed, checked-in, checked-out, cancelled
        this.totalPrice = data.totalPrice || 0;
        this.paymentStatus = data.paymentStatus || 'unpaid'; // unpaid, partially-paid, paid
        this.specialRequests = data.specialRequests || '';
    }

    static fromJson(json) {
        return new Booking(json);
    }

    toJson() {
        return {
            id: this.id,
            guestId: this.guestId,
            roomId: this.roomId,
            checkIn: this.checkIn,
            checkOut: this.checkOut,
            status: this.status,
            totalPrice: this.totalPrice,
            paymentStatus: this.paymentStatus,
            specialRequests: this.specialRequests
        };
    }
} 