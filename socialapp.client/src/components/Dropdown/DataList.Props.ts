import { DropdownDataOption } from '../../models/DropdownDataOption';

export interface DataListProps {
  data: Array<DropdownDataOption>;
  onChange: (evt: any) => void;
}