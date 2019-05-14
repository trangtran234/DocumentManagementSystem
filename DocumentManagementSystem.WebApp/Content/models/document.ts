import { Tag } from "./tag";
import { User } from "./user";

export class Document {
    Id: number;
    Description: string;
    FileType: string;
    //tag: Tag;
    Created: string;
    //createdBy: User;
    LastModified: string;
    //lastModifiedBy: User;
}