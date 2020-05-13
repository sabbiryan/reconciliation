import { DtoBase } from "src/shared/dto-base.model";

export class ReconciliationFormDto extends DtoBase<string> {
    year: number | undefined;
    month: number | undefined;
    incomeOrExpenseTypeId: string | undefined;
    amount: number | undefined;
}