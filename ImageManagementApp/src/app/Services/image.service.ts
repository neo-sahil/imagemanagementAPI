import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Image } from '../models/image';

@Injectable({
    providedIn: 'root'
})
export class ImageService {
    private apiUrl = 'http://localhost:5000/api/images';

    constructor(private http: HttpClient) { }

    getImages(): Observable<Image[]> {
        return this.http.get<Image[]>(this.apiUrl);
    }

    getImage(id: number): Observable<Image> {
        return this.http.get<Image>(`${this.apiUrl}/${id}`);
    }

    createImage(image: Image): Observable<Image> {
        return this.http.post<Image>(this.apiUrl, image);
    }

    updateImage(image: Image): Observable<void> {
        return this.http.put<void>(`${this.apiUrl}/${image.id}`, image);
    }

    deleteImage(id: number): Observable<void> {
        return this.http.delete<void>(`${this.apiUrl}/${id}`);
    }
}
