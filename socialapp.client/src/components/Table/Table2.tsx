import * as React from 'react';
import { TableRow } from './TableRow';
import './Table.css';

export interface TableProps2 {
    tableName: string;
    data: Array<TableRow>;
    getModal: () => JSX.Element;
    elementClick: (elemeny: TableRow) => void;
}

export function Table2(props: TableProps2) {

    let getElem = (element: TableRow, index: number) => {
        return (
            <tr key={index} className="table__tbody__tr">
                <td className="table__tbody__tr__td">
                    <button onClick={() => { props.elementClick(element); }}>{element.name}</button>
                </td>
            </tr>
        );
    };

    let renderOption = (element: TableRow, index: number) => {
        return (
            getElem(element, index)
        );
    };

    if (props.data.length === 0) {
        return <div> No elems in table {props.tableName} </div>;
    }
    return (
        <div>
            <table className="table">
                <thead className="table__thead">
                    <tr>
                        <th>{props.tableName}</th>
                    </tr>
                </thead>
                <tbody className="table__tbody">
                    {props.data.map(renderOption)}
                </tbody>

            </table>
            {props.getModal()}

        </div>
    );
}
