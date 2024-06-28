import { ProgramContent } from "./program-content.model";

export interface MeditationProgram{
    id: number;
    programName: string;
    s3UrlFoto: string;
    programContents: ProgramContent[];
}