module rootApp.model {
    import User = rootApp.model.User;
    import Tag = rootApp.model.Tag;

    export class Document {
        id?: number;
        documentName?: string;
        documentType?: string;
        documentSize?: number;
        documentDescription?: string;
        created?: Date;
        lastModified?: Date;
        createdBy?: User;
        lastModifiedBy?: User;
        tags?: Array<Tag>;
        statusUpload?: number;
        documentContent?: Uint8Array;
        documentTypes?: Array<DocumentType>;
        parentId?: number;
    }
}