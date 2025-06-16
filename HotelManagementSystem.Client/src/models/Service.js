export class Service {
    constructor(data = {}) {
        this.id = data.id || null;
        this.name = data.name || '';
        this.description = data.description || '';
        this.price = data.price || 0;
        this.category = data.category || '';
        this.isAvailable = data.isAvailable ?? true;
        this.duration = data.duration || 0; // в минутах
    }

    static fromJson(json) {
        return new Service(json);
    }

    toJson() {
        return {
            id: this.id,
            name: this.name,
            description: this.description,
            price: this.price,
            category: this.category,
            isAvailable: this.isAvailable,
            duration: this.duration
        };
    }
} 