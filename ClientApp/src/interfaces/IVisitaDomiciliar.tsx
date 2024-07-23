import { ICidadao } from "./ICidadao";
import { IDomicilio } from "./IDomicilio";
import { IEstabelecimento } from "./IEstabelecimento";
import { IFuncionario } from "./IFuncionario";

export interface IVisitaDomiciliar {
    id: number;
    funcionarioId: number;
    codigoDomicilio: string;
    cidadaoId: number | undefined;
    estabelecimentoId: number;
    equipeId: number;
    data: Date;
    turno: number;
    cboId: number;
    microArea: string;
    cns: string;
    nascimento: Date;
    latitude: number | undefined;
    longitude: number | undefined;

    domicilio: IDomicilio | undefined;
    cidadao: ICidadao | undefined;
    funcionario: IFuncionario | undefined;
    estabelecimento: IEstabelecimento | undefined;
}