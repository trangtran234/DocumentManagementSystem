module rootApp.model {
    import User = rootApp.model.User;
    import Tag = rootApp.model.Tag;

    export class Document {
        id?: number;
        documentName?: string;
        documentType?: string;
        documentSize?: number;
        documentDescription?: string;
        created?: string;
        lastModified?: string;
        createdBy?: User;
        lastModifiedBy?: User;
        tags?: Array<Tag>;
        statusUpload?: number;
        documentContent?: Uint8Array;
        documentTypes?: Array<DocumentType>;
    }
}