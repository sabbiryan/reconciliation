import { DtoBase } from "src/shared/dto-base.model";
import { IncomeOrExpenseFlag } from "../enums/income-or-expense-flag.enum";

export class IncomeOrExpenseTypeDto extends DtoBase<string> {
    displayName!: string;
    flag: IncomeOrExpenseFlag | undefined;
    flagDisplayText: string | undefined;
}