module rootApp.model {
    export class DocumentTree {
        id?: number;
        documentName?: string;
        parentId?: number;
        childrens?: DocumentTree[];
        isExpanded?: boolean;
    }
}