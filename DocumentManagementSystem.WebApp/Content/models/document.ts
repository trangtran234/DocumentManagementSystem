import { User } from "./user";
import { Tag } from "./tag";

export class Document {
    id: number;
    documentName: string;
    documentType: string;
    documentSize: number;
    documentDescription: string;
    created: string;
    lastModified: string;
    createdBy: User;
    lastModifiedBy: User;
    tags: Array<Tag>;
}