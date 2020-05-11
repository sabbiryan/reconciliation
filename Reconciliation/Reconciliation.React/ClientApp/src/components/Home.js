import React, { Component } from 'react';


export class Home extends Component {
    static displayName = Home.name;

    constructor(props) {
        super(props);
        this.state = { grid: undefined, loading: true, isEditing: false, editRowIndex: undefined, editColIndex: undefined, cell: undefined };

        this.handleEditCellClick = this.handleCellEditClick.bind(this);
        this.handleResetCellEditClick = this.handleResetCellEditClick.bind(this);

        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }


    componentDidMount() {
        this.populateReconciliationGrid();
    }


    handleCellEditClick(event) {
        this.setState({ isEditing: true });
    }

    handleResetCellEditClick(event) {
        this.setState({ isEditing: false });
    }

    

    handleChange(event) {
        this.setState({ cell: event.target.value });
    }

    handleSubmit(event) {
        alert('A name was submitted: ' + this.state.cell);
        event.preventDefault();
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

    static renderReconciliationTableEditableRows(rows, self) {

        return (
            rows.map((row, rowIndex) => {
                return <tr key={row.incomeOrExpenseTypeName} className={row.flag == 1 ? 'table-success' : 'table-danger'}>
                    <td>{row.incomeOrExpenseTypeName}</td>
                    {row.columns.map((col, colIndex) => {

                        let props = {
                            col: col,
                            tdOnClick: self.handleEditCellClick,
                            formOnSubmit: self.handleSubmit,
                            formOnChange: self.handleChange,
                            formOnBlur: self.handleResetCellEditClick,
                            cellState: self.state.cell,
                            isEditingState: self.state.isEditing,
                        };

                        return <EditableTableCell key={col.month} {...props} />
                    })}
                </tr>
            })
        );
    }


    static renderReconciliationTable(grid, self) {
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

                    {Home.renderReconciliationTableEditableRows(grid.rows, self)}

                    {Home.renderReconciliationTableStatementsOrResults(grid.results, 'table-warning')}
                </tbody>
            </table>
        );
    }

    render() {

        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Home.renderReconciliationTable(this.state.grid, this);

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

    async populateReconciliationGrid() {
        const response = await fetch('reconciliation/yearly-table');
        const data = await response.json();
        this.setState({ grid: data, loading: false });
    }

}

function ViewTableCell(props) {
    return (
        <td title='Click to edit' onClick={props.tdOnClick}>{props.col.amount}</td>
    )
}

function FormTableCell(props) {
    return (
        <td>
            <form onSubmit={props.formOnSubmit}>
                <input type="text" value={props.cellState} onChange={props.formOnChange} onBlur={props.formOnBlur} required />
            </form>
        </td>
    )
}

function EditableTableCell(props) {
    const isView = !props.isEditingState;
    if (isView) {
        return <ViewTableCell {...props} />;
    }
    return <FormTableCell {...props} />;
}