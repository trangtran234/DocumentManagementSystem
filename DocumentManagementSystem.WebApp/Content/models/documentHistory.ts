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
    }
}