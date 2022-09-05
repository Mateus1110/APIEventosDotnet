import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  public eventos: any = [];
  public eventosFiltrados: any = [];
  private _filtro: string = '';
  imgWidth = 80;
  imgHeigth = 50;
  showImage = true;

  public get filtro(): string {
    return this._filtro;
  }

  public set filtro(value: string) {
    this._filtro = value;
    this.eventosFiltrados = this._filtro ? this.filtrarEventos(this._filtro) : this.eventos
  }

  filtrarEventos(filter: string): any {
    filter = filter.toLocaleLowerCase();
    return this.eventos.filter(
      (evento: any) => evento.tema.toLocaleLowerCase().indexOf(filter) !== -1 ||
                       evento.local.toLocaleLowerCase().indexOf(filter) !== -1
    )
  }

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getEventos();
  }

  showImagem() {
    this.showImage = !this.showImage
  }

  public getEventos(): void {
    this.http.get('https://localhost:5001/api/Evento').subscribe({
       next: (v) => {this.eventos = v;
                     this.eventosFiltrados = this.eventos},
       error: console.error}
    );
  }
}
