import { TableRow } from './TableRow';

export interface TableProps {
  tableName: string;
  data: Array<TableRow>;
  link: (id: number) => string;
}