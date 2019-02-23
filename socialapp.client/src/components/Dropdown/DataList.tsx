
import * as React from 'react';
import { DropdownDataOption } from '../../models/DropdownDataOption';
import { DataListProps } from './DataList.Props';

export function DataList(props: DataListProps) {

    let renderOption = (element: DropdownDataOption, index: number) => {
        return (
            <option key={index} value={element.label} />
        );
    };

    return (
        <div className="block__create__dataList">
            <input list="options" onChange={props.onChange} />
            <datalist id="options">
                {props.data.map(renderOption)}
            </datalist>
        </div>
    );
}
