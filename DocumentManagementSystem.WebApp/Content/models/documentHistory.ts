module rootApp.model {
    import User = rootApp.model.User;

    export enum HistoryAction {
        Upload = 1,
        Edit = 2,
        Delete = 3
    }

    export class DocumentHistory {
        id?: number;
        documentId?: number;
        actionEvent?: HistoryAction;
        account?: User;
        date?: Date;


        constructor(id: number, documentId: number, actionEvent: HistoryAction, account: User, date: Date) {
            this.id = id;
            this.documentId = documentId;
            this.actionEvent = actionEvent;
            this.account = account;
            this.date = date;
        }
    }
}