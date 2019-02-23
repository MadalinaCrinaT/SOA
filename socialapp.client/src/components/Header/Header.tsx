import * as React from 'react';
import { HeaderProps } from './Header.Props';
import { Link } from 'react-router-dom';
import './Header.css';
import { AuthService } from '../../services/Auth.Service';
interface HeaderState {
  data: Array<any>;
  links: Array<string>;
  names: Array<string>;
  lastIndex: number;
}

export class Header extends React.Component<HeaderProps, HeaderState> {
  constructor(props: HeaderProps) {
    super(props);
    this.state = {
      data: [],
      links: ['/home', '/groups'],
      names: ['Home', 'Groups'],
      lastIndex: 0,
    };
  }

  getNormalLink(url: string, name: string, index: number) {
    return (
      <span >
        <Link
          to={url}
          className="header__link normal"
          onClick={() => this.makeBold(index)}
        >{name}
        </Link>
      </span>
    );
  }

  getBoldLink(url: string, name: string, index: number) {
    return (
      <span >
        <Link
          to={url}
          className="header__link boldLink"
          onClick={() => this.makeBold(index)}
        >{name}
        </Link>
      </span>
    );
  }

  makeBold(index: any) {
    let array = this.state.data;
    let lastIndex = this.state.lastIndex;
    array[lastIndex] = this.getNormalLink(this.state.links[lastIndex], this.state.names[lastIndex], lastIndex);
    array[index] = this.getBoldLink(this.state.links[index], this.state.names[index], index);
    this.setState({
      data: array,
      lastIndex: index
    });
  }

  componentDidMount() {
    let array = new Array<any>();
    for (let i = 0; i < this.state.links.length; i++) {
      array.push(this.getNormalLink(this.state.links[i], this.state.names[i], i));

    }
    this.setState({
      data: array
    });
  }

  renderLink = (element: any, index: number) => {
    return (
      element
    );
  }

  render() {
    return (
      <div className="block__header">
        <header className="header">
          <span className="block__userName"> {AuthService.getUserName()}</span>
          {this.state.data.map(this.renderLink)}
        </header>
      </div>
    );
  }
}
