import { DtoBase } from "src/shared/dto-base.model";
import { Month } from "../enums/month.enum";
import { IncomeOrExpenseTypeDto } from "./income-or-expense-type-dto.model";

export class ReconciliationListDto extends DtoBase<string> {
    incomeOrExpenseTypeId: string | undefined;
    incomeOrExpenseType: IncomeOrExpenseTypeDto | undefined;
    month: Month | undefined;
    monthDisplayText: string | undefined;
    amount: number | undefined;
}