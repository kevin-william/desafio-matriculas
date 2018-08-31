import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'matriculaSemDV',
    templateUrl: './matriculaSemDV.component.html'
})
export class MatriculaSemDVComponent {

    private baseUrl: string;

    constructor(private http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.baseUrl = baseUrl;
    }

    public upload(files: File[]) {

        if (files.length === 0) return;

        let formData = new FormData();

        formData.append(files[0].name, files[0]);

        this.http
            .post(this.baseUrl + "api/Matricula/GerarDigitoVerificador", formData)
            .subscribe(response => {
                if (response.ok) {
                    let link = document.createElement("a");
                    link.href = URL.createObjectURL(new Blob([response.text()], { type: "application/octet-stream" }));
                    link.download = "matriculasComDV.txt";
                    link.click();
                } else {
                    console.error(response.text);
                }
            }, error => console.error(error));
    }
}
