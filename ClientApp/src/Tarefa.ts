import { StatusEnum } from "./app/status/StatusEnum";

export interface Tarefa{
    id?: number,
    titulo: string,
    descricao: string,
    dataVencimento: Date,
    status: StatusEnum
}