import * as React from 'react';
import { TableRow } from './TableRow';
import { Link } from 'react-router-dom';
import { TableProps } from './Table.Props';
import './Table.css';
export function Table(props: TableProps) {

    let renderOption = (element: TableRow, index: number) => {
        return (
            <tr key={index} className="table__tbody__tr">
                <td className="table__tbody__tr__td">
                    <Link to={props.link(element.id)} className="table__tbody__tr__td__link">  {element.name} </Link>
                </td>
            </tr>
        );
    };

    if (props.data.length === 0) {
        return <div > No elems in table {props.tableName} </div>;
    }
    return (
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
    );
}
