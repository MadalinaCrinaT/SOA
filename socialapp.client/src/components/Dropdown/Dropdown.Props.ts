import { DropdownDataOption } from '../../models/DropdownDataOption';

export interface DropdownProps {
  data: Array<DropdownDataOption>;
  onClick?: (i: number) => void;
  onChange: (evt: any) => void;
}