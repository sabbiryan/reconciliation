import { Month } from "../enums/month.enum";
import { IncomeOrExpenseFlag } from "../enums/income-or-expense-flag.enum";

export class YearlyReconciliationGridDto {
    year: number | undefined;
    titles: YearlyReconciliationGridTitleDto[] | undefined;
    statements: YearlyReconciliationGridResultDto[] | undefined;
    rows: YearlyReconciliationGridRowDto[] = [];
    results: YearlyReconciliationGridResultDto[] = [];
}

export class YearlyReconciliationGridTitleDto {
    month: Month = 1;
    monthDisplayName: string | undefined;
}

export class YearlyReconciliationGridRowDto {
    incomeOrExpenseTypeName: string | undefined;
    columns: YearlyReconciliationGridColumnDto[] = [];
    flag: IncomeOrExpenseFlag = 1;
}

export class YearlyReconciliationGridColumnDto {
    constructor() {
        this.amount = 0;
    }
    
    id: string | undefined;
    incomeOrExpenseTypeId: string | undefined;
    year: number | undefined;
    month: Month = 1;
    amount: number | null | undefined;
    flag: IncomeOrExpenseFlag = 1;
}

export class YearlyReconciliationGridResultDto {
    order: number | undefined;
    title: string | undefined;
    values: YearlyReconciliationGridResultValueDto[] = [];
}

export class YearlyReconciliationGridResultValueDto {
    constructor() {
        this.amount = 0;
    }

    month: Month = 1;
    amount: number | null | undefined;
}