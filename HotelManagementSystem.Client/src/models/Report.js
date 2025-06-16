export class Report {
    constructor(data = {}) {
        this.id = data.id || null;
        this.reportType = data.reportType || '';
        this.startDate = data.startDate || null;
        this.endDate = data.endDate || null;
        this.generatedAt = data.generatedAt || new Date();
        this.data = data.data || {};
        this.format = data.format || 'pdf'; // pdf, excel, csv
    }

    static fromJson(json) {
        return new Report(json);
    }

    toJson() {
        return {
            id: this.id,
            reportType: this.reportType,
            startDate: this.startDate,
            endDate: this.endDate,
            generatedAt: this.generatedAt,
            data: this.data,
            format: this.format
        };
    }
} 