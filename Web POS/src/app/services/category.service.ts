import { Injectable } from '@angular/core';
import { AlertService } from './../shared/services/alert.service';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment as env } from './../../environments/environment';
import { endpoint } from './../shared/apis/endpoints';
import { ListCategoryRequest } from './../requests/category/list-category.request';
import { Category, CategoryApi } from '../responses/category/category.response';
import { map } from 'rxjs/operators';
import { CategoryRequest } from '../requests/category/category.request';
import { ApiResponse } from '../commons/response.interface';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor(
    private _http: HttpClient,
    private _alert: AlertService
    ) { }

    GetAll(size, sort, order, page = 1, getInputs): Observable<any>{
      const requestURL = `${env.api}${endpoint.LIST_CATEGORIES}`;
      const params: ListCategoryRequest = new ListCategoryRequest(
        page + 1,
        order,
        sort,
        size,
        getInputs.numFilter,
        getInputs.textFilter,
        getInputs.stateFilter,
        getInputs.startDate,
        getInputs.endDate        
      );
      return this._http.post<CategoryApi>(requestURL, params).pipe(
        map((data: CategoryApi) => {
          data.data.items.forEach(e => {
            switch (e.state) {
              case 0:
                e.badgeColor = 'text-gray bg-gray-light';
                break;
              case 1:
                e.badgeColor = 'text-green bg-green-light';
                break;
              default:
                e.badgeColor = 'text-gray bg-gray-light';
                break;
            }
          });
          return data;
        })
      );
    }

    CategoryRegister(category: CategoryRequest): Observable<ApiResponse> {
      const requestURL = `${env.api}${endpoint.CATEGORY_REGISTER}`;
      return this._http.post(requestURL, category).pipe(
        map((resp: ApiResponse) => {
          return resp;
        })
      );
    }
  CategoryById(CategoryId: number): Observable<Category> {
    const requestURL = `${env.api}${endpoint.CATEGORY_BY_ID}${CategoryId}`;
    return this._http.get(requestURL).pipe(
      map((resp: ApiResponse) => {
        return resp.data;
      })
    );
  }

  CategoryEdit(categoryId: number, category: CategoryRequest): Observable<ApiResponse> {
    const requestURL = `${env.api}${endpoint.CATEGORY_EDIT}${categoryId}`;
    return this._http.put(requestURL, category).pipe(
      map((resp: ApiResponse) => {
        return resp;
      })
    );
  }

  CategoryRemove(categoryId: number): Observable<void> {
    const requestURL = `${env.api}${endpoint.CATEGORY_REMOVE}${categoryId}`;
    return this._http.put(requestURL, '').pipe(
      map((resp: ApiResponse) => {
        if (resp.isSuccess) {
          this._alert.sucess('Excelente', resp.message);
        }
      })
    );
  }
}
