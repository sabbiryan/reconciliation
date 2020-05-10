import React, { Component } from 'react';

export class Home extends Component {
    static displayName = Home.name;
    static isEditing = false;
    static editRowIndex = undefined;
    static editColIndex = undefined;

    constructor(props) {
        super(props);
        this.state = { grid: undefined, loading: true };
    }

    componentDidMount() {
        this.populateWeatherData();
    }



    static renderReconciliationTableTitles(titles) {
        return (
            titles.map((item, index) => {
                return <td key={item.month}>{item.monthDisplayName}</td>
            })
        );
    }


    static renderReconciliationTableStatementsOrResults(statementsOrResults, className) {
        return (
            statementsOrResults.map((row, index) => {
                return <tr className={className} key={row.title}>
                    <td>{row.title}</td>
                    {row.values.map(col => {
                        return <td key={col.month}>{col.amount}</td>
                    })}
                </tr>
            })
        );
    }

    static editCell(rowIndex, colIndex) {
        this.isEditing = true;
        this.rowIndex = rowIndex;
        this.colIndex = colIndex;
    }

    static renderReconciliationTableEditableRows(rows) {
        return (
            rows.map((row, rowIndex) => {
                return <tr key={row.incomeOrExpenseTypeName} className={row.flag == 1 ? 'table-success' : 'table-danger'}>
                    <td>{row.incomeOrExpenseTypeName}</td>
                    {row.columns.map((col, colIndex) => {
                        if (!this.isEditing) {
                            return <td key={col.month} title='Click to edit' onClick={() => this.editCell(rowIndex, colIndex)}>{col.amount}</td>

                        } else if (this.isEditing) {
                            return <input type='number' ></input>
                        }
                    })}
                </tr>
            })
        );
    }


    static renderReconciliationTable(grid) {
        return (
            <table className='table table-striped table-bordered' aria-labelledby="tabelLabel">
                <thead>
                    <tr className="text-center">
                        <th colSpan="14">Year {grid.year}</th>
                    </tr>
                    <tr>
                        <td></td>
                        {Home.renderReconciliationTableTitles(grid.titles)}
                    </tr>
                </thead>

                <tbody>
                    {Home.renderReconciliationTableStatementsOrResults(grid.statements, 'table-secondary')}

                    {Home.renderReconciliationTableEditableRows(grid.rows)}

                    {Home.renderReconciliationTableStatementsOrResults(grid.results, 'table-warning')}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Home.renderReconciliationTable(this.state.grid);

        return (
            <div>
                <h6 id="tabelLabel" className="text-center">We are in React App</h6>
                {contents}


                <div className="row mb-5">
                    <div className="col-12 text-center">
                        <span className="badge badge-secondary">Readonly</span>
                        &nbsp;&nbsp;
                        <span className="badge badge-success">Income</span>
                        &nbsp;&nbsp;
                        <span className="badge badge-danger">Expense</span>
                    </div>
                </div>
            </div>


        );
    }

    async populateWeatherData() {
        const response = await fetch('reconciliation/yearly-table');
        const data = await response.json();
        this.setState({ grid: data, loading: false });
    }
}
