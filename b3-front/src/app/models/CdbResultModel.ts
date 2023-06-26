export interface CdbResultModel {
  bruto: number;
  liquido: number;
  success: boolean;
  message: string;
  data: CdbResultDataModel[];
}

export interface CdbResultDataModel {
  key: string;
  message: string;
}
