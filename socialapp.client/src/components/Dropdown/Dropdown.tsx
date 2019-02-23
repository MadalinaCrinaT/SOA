
import * as React from 'react';
import { DropdownProps } from './Dropdown.Props';
import { DropdownDataOption } from '../../models/DropdownDataOption';

export function Dropdown(props: DropdownProps) {

    let renderOption = (element: DropdownDataOption, index: number) => {
        return (
            <option key={index} value={element.value}>{element.label}</option>
        );
    };

    return (
        <div className="dropdownList">
            <select onChange={props.onChange}>
                <option value="SelectValue" >Select value</option>
                {props.data.map(renderOption)}
            </select>
        </div>
    );

}
